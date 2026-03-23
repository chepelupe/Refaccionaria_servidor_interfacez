// Estado del carrito
let carrito = [];
let productos = [];
let marcas = [];

// Inicializar página de ventas
document.addEventListener('DOMContentLoaded', async () => {
    if (!Auth.checkAuth()) return;
    Auth.updateUserInfo();
    updateDateTime();
    await cargarProductos();
    await cargarMarcas();
    setupEventListeners();
    
    // Actualizar hora cada segundo
    setInterval(updateDateTime, 1000);
});

function updateDateTime() {
    const now = new Date();
    const dateTimeStr = now.toLocaleString('es-MX');
    const dateTimeElements = document.querySelectorAll('#currentDateTime');
    dateTimeElements.forEach(el => {
        if (el) el.textContent = dateTimeStr;
    });
}

async function cargarProductos() {
    try {
        productos = await ApiClient.get(API_CONFIG.endpoints.productos);
        renderProductosGrid(productos);
    } catch (error) {
        console.error('Error cargando productos:', error);
        document.getElementById('productosGrid').innerHTML = '<div class="error">Error al cargar productos</div>';
    }
}

async function cargarMarcas() {
    try {
        marcas = await ApiClient.get(API_CONFIG.endpoints.marcas);
        const marcaMap = {};
        marcas.forEach(m => marcaMap[m.idMarca] = m.nombre);
        window.marcaMap = marcaMap;
    } catch (error) {
        console.error('Error cargando marcas:', error);
    }
}

function renderProductosGrid(productosList) {
    const grid = document.getElementById('productosGrid');
    if (!grid) return;
    
    if (productosList.length === 0) {
        grid.innerHTML = '<div class="loading">No hay productos disponibles</div>';
        return;
    }
    
    grid.innerHTML = productosList.map(producto => `
        <div class="producto-card" onclick="agregarAlCarrito(${producto.idProducto})">
            <h4>${escapeHtml(producto.nombre)}</h4>
            <p class="precio">$${formatNumber(producto.precioVenta)}</p>
            <p class="stock">Stock: ${producto.stockActual}</p>
        </div>
    `).join('');
}

function agregarAlCarrito(productoId) {
    const producto = productos.find(p => p.idProducto === productoId);
    if (!producto) return;
    
    if (producto.stockActual <= 0) {
        alert('Producto sin stock disponible');
        return;
    }
    
    const itemExistente = carrito.find(item => item.idProducto === productoId);
    
    if (itemExistente) {
        if (itemExistente.cantidad + 1 > producto.stockActual) {
            alert(`Stock insuficiente. Solo quedan ${producto.stockActual} unidades`);
            return;
        }
        itemExistente.cantidad++;
        itemExistente.subtotal = itemExistente.cantidad * itemExistente.precio;
    } else {
        carrito.push({
            idProducto: producto.idProducto,
            nombre: producto.nombre,
            precio: producto.precioVenta,
            cantidad: 1,
            subtotal: producto.precioVenta
        });
    }
    
    renderCarrito();
}

function renderCarrito() {
    const tbody = document.getElementById('carritoBody');
    if (!tbody) return;
    
    if (carrito.length === 0) {
        tbody.innerHTML = '<tr><td colspan="5" class="empty-carrito">Carrito vacío</td></tr>';
        document.getElementById('subtotal').textContent = '$0.00';
        document.getElementById('total').textContent = '$0.00';
        return;
    }
    
    tbody.innerHTML = carrito.map((item, index) => `
        <tr>
            <td>${escapeHtml(item.nombre)}</td>
            <td>
                <button onclick="modificarCantidad(${index}, -1)">-</button>
                ${item.cantidad}
                <button onclick="modificarCantidad(${index}, 1)">+</button>
            </td>
            <td>$${formatNumber(item.precio)}</td>
            <td>$${formatNumber(item.subtotal)}</td>
            <td><button class="btn-danger" onclick="eliminarDelCarrito(${index})">🗑️</button></td>
        </tr>
    `).join('');
    
    const subtotal = carrito.reduce((sum, item) => sum + item.subtotal, 0);
    document.getElementById('subtotal').textContent = `$${formatNumber(subtotal)}`;
    document.getElementById('total').textContent = `$${formatNumber(subtotal)}`;
    
    recalcularCambio();
}

function modificarCantidad(index, delta) {
    const item = carrito[index];
    const producto = productos.find(p => p.idProducto === item.idProducto);
    
    const nuevaCantidad = item.cantidad + delta;
    
    if (nuevaCantidad <= 0) {
        eliminarDelCarrito(index);
        return;
    }
    
    if (nuevaCantidad > producto.stockActual) {
        alert(`Stock insuficiente. Solo quedan ${producto.stockActual} unidades`);
        return;
    }
    
    item.cantidad = nuevaCantidad;
    item.subtotal = item.cantidad * item.precio;
    
    renderCarrito();
}

function eliminarDelCarrito(index) {
    carrito.splice(index, 1);
    renderCarrito();
}

function recalcularCambio() {
    const montoRecibido = parseFloat(document.getElementById('montoRecibido')?.value || 0);
    const total = carrito.reduce((sum, item) => sum + item.subtotal, 0);
    const cambio = montoRecibido - total;
    
    const cambioSpan = document.getElementById('cambio');
    if (cambioSpan) {
        cambioSpan.textContent = cambio >= 0 ? `$${formatNumber(cambio)}` : `Faltan $${formatNumber(Math.abs(cambio))}`;
        cambioSpan.style.color = cambio >= 0 ? '#27ae60' : '#e74c3c';
    }
}

async function finalizarVenta() {
    if (carrito.length === 0) {
        alert('Agregue productos al carrito');
        return;
    }
    
    const montoRecibido = parseFloat(document.getElementById('montoRecibido').value || 0);
    const total = carrito.reduce((sum, item) => sum + item.subtotal, 0);
    const metodoPago = document.getElementById('metodoPago').value;
    
    if (montoRecibido < total && metodoPago === 'Efectivo') {
        alert(`El monto recibido ($${formatNumber(montoRecibido)}) es menor al total ($${formatNumber(total)})`);
        return;
    }
    
    const venta = {
        venta: {
            fechaHora: new Date().toISOString(),
            subtotal: total,
            total: total,
            montoRecibido: metodoPago === 'Efectivo' ? montoRecibido : total,
            cambioEntregado: metodoPago === 'Efectivo' ? montoRecibido - total : 0,
            metodoPago: metodoPago,
            estado: true
        },
        detalles: carrito.map(item => ({
            fkProducto: item.idProducto,
            cantidad: item.cantidad,
            precioUnitarioVenta: item.precio,
            subtotal: item.subtotal
        }))
    };
    
    try {
        const result = await ApiClient.post(API_CONFIG.endpoints.ventas, venta);
        alert(result.mensaje || 'Venta registrada con éxito');
        
        // Limpiar carrito y recargar productos
        carrito = [];
        renderCarrito();
        await cargarProductos();
        document.getElementById('montoRecibido').value = 0;
        
    } catch (error) {
        alert('Error al registrar la venta: ' + error.message);
    }
}

function setupEventListeners() {
    const searchInput = document.getElementById('searchProduct');
    if (searchInput) {
        searchInput.addEventListener('input', (e) => {
            const searchTerm = e.target.value.toLowerCase();
            const filtered = productos.filter(p => 
                p.nombre.toLowerCase().includes(searchTerm) ||
                (p.codigoBarras && p.codigoBarras.includes(searchTerm))
            );
            renderProductosGrid(filtered);
        });
    }
    
    const montoRecibido = document.getElementById('montoRecibido');
    if (montoRecibido) {
        montoRecibido.addEventListener('input', recalcularCambio);
    }
    
    const btnFinalizar = document.getElementById('btnFinalizarVenta');
    if (btnFinalizar) {
        btnFinalizar.addEventListener('click', finalizarVenta);
    }
}

// Funciones helper
function formatNumber(num) {
    return num.toLocaleString('es-MX', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function escapeHtml(text) {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

// Exponer funciones globalmente
window.agregarAlCarrito = agregarAlCarrito;
window.modificarCantidad = modificarCantidad;
window.eliminarDelCarrito = eliminarDelCarrito;