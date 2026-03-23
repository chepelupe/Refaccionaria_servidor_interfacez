let productos = [];
let marcas = [];
let tiposProductos = [];

document.addEventListener('DOMContentLoaded', async () => {
    if (!Auth.checkAuth()) return;
    Auth.updateUserInfo();
    await cargarProductos();
    await cargarMarcas();
    await cargarTiposProductos();
    setupEventListeners();
});

async function cargarProductos() {
    try {
        productos = await ApiClient.get(API_CONFIG.endpoints.productos);
        renderProductosTable();
    } catch (error) {
        console.error('Error cargando productos:', error);
        document.getElementById('productosTable').innerHTML = '<tr><td colspan="6">Error al cargar productos</td></tr>';
    }
}

async function cargarMarcas() {
    try {
        marcas = await ApiClient.get(API_CONFIG.endpoints.marcas);
        const marcaSelect = document.getElementById('prodMarca');
        const filtroMarca = document.getElementById('filtroMarca');
        
        if (marcaSelect) {
            marcaSelect.innerHTML = '<option value="">Seleccione una marca</option>' +
                marcas.map(m => `<option value="${m.idMarca}">${escapeHtml(m.nombre)}</option>`).join('');
        }
        
        if (filtroMarca) {
            filtroMarca.innerHTML = '<option value="">Todas las marcas</option>' +
                marcas.map(m => `<option value="${m.idMarca}">${escapeHtml(m.nombre)}</option>`).join('');
            filtroMarca.addEventListener('change', filtrarProductos);
        }
    } catch (error) {
        console.error('Error cargando marcas:', error);
    }
}

async function cargarTiposProductos() {
    try {
        tiposProductos = await ApiClient.get(API_CONFIG.endpoints.tiposProductos);
        const tipoSelect = document.getElementById('prodTipo');
        if (tipoSelect) {
            tipoSelect.innerHTML = '<option value="">Seleccione un tipo</option>' +
                tiposProductos.map(t => `<option value="${t.idTipoProducto}">${escapeHtml(t.nombre)}</option>`).join('');
        }
    } catch (error) {
        console.error('Error cargando tipos de productos:', error);
    }
}

function renderProductosTable() {
    const tbody = document.getElementById('productosTable');
    if (!tbody) return;
    
    const filtroTexto = document.getElementById('filtroProducto')?.value.toLowerCase() || '';
    const filtroMarca = document.getElementById('filtroMarca')?.value || '';
    
    const marcaMap = {};
    marcas.forEach(m => marcaMap[m.idMarca] = m.nombre);
    
    let filtered = productos;
    
    if (filtroTexto) {
        filtered = filtered.filter(p => p.nombre.toLowerCase().includes(filtroTexto));
    }
    
    if (filtroMarca) {
        filtered = filtered.filter(p => p.fkMarca == filtroMarca);
    }
    
    if (filtered.length === 0) {
        tbody.innerHTML = '<tr><td colspan="6">No hay productos</td></tr>';
        return;
    }
    
    tbody.innerHTML = filtered.map(producto => `
        <tr>
            <td>${producto.idProducto}</td>
            <td>${escapeHtml(producto.nombre)}</td>
            <td>${escapeHtml(marcaMap[producto.fkMarca] || 'N/A')}</td>
            <td>$${formatNumber(producto.precioVenta)}</td>
            <td class="${producto.stockActual <= (producto.stockMinimo || 5) ? 'bajo-stock' : ''}">
                ${producto.stockActual}
            </td>
            <td>
                <button class="btn-secondary" onclick="editarProducto(${producto.idProducto})">✏️ Editar</button>
            </td>
        </tr>
    `).join('');
}

function filtrarProductos() {
    renderProductosTable();
}

function editarProducto(id) {
    const producto = productos.find(p => p.idProducto === id);
    if (!producto) return;
    
    document.getElementById('modalTitle').textContent = 'Editar Producto';
    document.getElementById('productoId').value = producto.idProducto;
    document.getElementById('prodNombre').value = producto.nombre;
    document.getElementById('prodMarca').value = producto.fkMarca;
    document.getElementById('prodTipo').value = producto.fkTipoProducto || '';
    document.getElementById('prodPrecioCompra').value = producto.precioCompra;
    document.getElementById('prodPrecioVenta').value = producto.precioVenta;
    document.getElementById('prodStockActual').value = producto.stockActual;
    document.getElementById('prodStockMinimo').value = producto.stockMinimo || '';
    document.getElementById('prodModelo').value = producto.modelo || '';
    document.getElementById('prodCodigoBarras').value = producto.codigoBarras || '';
    
    document.getElementById('productoModal').style.display = 'block';
}

function setupEventListeners() {
    const btnNuevo = document.getElementById('btnNuevoProducto');
    if (btnNuevo) {
        btnNuevo.addEventListener('click', () => {
            document.getElementById('modalTitle').textContent = 'Nuevo Producto';
            document.getElementById('productoForm').reset();
            document.getElementById('productoId').value = '';
            document.getElementById('productoModal').style.display = 'block';
        });
    }
    
    const closeBtn = document.querySelector('.close');
    if (closeBtn) {
        closeBtn.addEventListener('click', () => {
            document.getElementById('productoModal').style.display = 'none';
        });
    }
    
    const filtroProducto = document.getElementById('filtroProducto');
    if (filtroProducto) {
        filtroProducto.addEventListener('input', filtrarProductos);
    }
    
    const productoForm = document.getElementById('productoForm');
    if (productoForm) {
        productoForm.addEventListener('submit', async (e) => {
            e.preventDefault();
            await guardarProducto();
        });
    }
    
    window.addEventListener('click', (e) => {
        const modal = document.getElementById('productoModal');
        if (e.target === modal) {
            modal.style.display = 'none';
        }
    });
}

async function guardarProducto() {
    const productoId = document.getElementById('productoId').value;
    const producto = {
        nombre: document.getElementById('prodNombre').value,
        fkMarca: parseInt(document.getElementById('prodMarca').value),
        fkTipoProducto: parseInt(document.getElementById('prodTipo').value) || null,
        precioCompra: parseFloat(document.getElementById('prodPrecioCompra').value),
        precioVenta: parseFloat(document.getElementById('prodPrecioVenta').value),
        stockActual: parseInt(document.getElementById('prodStockActual').value),
        stockMinimo: parseInt(document.getElementById('prodStockMinimo').value) || null,
        modelo: document.getElementById('prodModelo').value || null,
        codigoBarras: document.getElementById('prodCodigoBarras').value || null,
        fkProveedor: 1 // Valor por defecto, ajustar según necesidad
    };
    
    try {
        let result;
        if (productoId) {
            // Actualizar producto (si tienes endpoint PUT)
            // result = await ApiClient.put(`${API_CONFIG.endpoints.productos}/${productoId}`, producto);
            alert('Función de edición pendiente de implementar en la API');
        } else {
            result = await ApiClient.post(API_CONFIG.endpoints.productos, producto);
            alert('Producto creado con éxito');
        }
        
        document.getElementById('productoModal').style.display = 'none';
        await cargarProductos();
        
    } catch (error) {
        alert('Error al guardar el producto: ' + error.message);
    }
}

// Funciones helper
function formatNumber(num) {
    return num.toLocaleString('es-MX', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function escapeHtml(text) {
    if (!text) return '';
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

// Exponer funciones globalmente
window.editarProducto = editarProducto;