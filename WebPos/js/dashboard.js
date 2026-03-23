document.addEventListener('DOMContentLoaded', async () => {
    if (!Auth.checkAuth()) return;
    Auth.updateUserInfo();
    updateDateTime();
    await cargarDashboardData();
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

async function cargarDashboardData() {
    try {
        const productos = await ApiClient.get(API_CONFIG.endpoints.productos);
        const ventas = await ApiClient.get(API_CONFIG.endpoints.ventas);
        
        // Total de productos
        document.getElementById('totalProductos').textContent = productos.length;
        
        // Productos con bajo stock
        const bajoStock = productos.filter(p => p.stockActual <= (p.stockMinimo || 5));
        document.getElementById('bajoStock').textContent = bajoStock.length;
        
        // Ventas de hoy
        const hoy = new Date().toISOString().split('T')[0];
        const ventasHoy = ventas.filter(v => v.fechaHora.split('T')[0] === hoy);
        const totalVentasHoy = ventasHoy.reduce((sum, v) => sum + v.total, 0);
        document.getElementById('ventasHoy').textContent = `$${formatNumber(totalVentasHoy)}`;
        
        // Marca más vendida (simplificado)
        document.getElementById('marcaTop').textContent = 'Calculando...';
        
        // Últimas ventas
        const ultimasVentas = ventas.slice(-5).reverse();
        renderRecentSales(ultimasVentas);
        
    } catch (error) {
        console.error('Error cargando dashboard:', error);
    }
}

function renderRecentSales(ventas) {
    const tbody = document.getElementById('recentSalesTable');
    if (!tbody) return;
    
    if (ventas.length === 0) {
        tbody.innerHTML = '<tr><td colspan="4">No hay ventas registradas</td></tr>';
        return;
    }
    
    tbody.innerHTML = ventas.map(venta => `
        <tr>
            <td>${venta.idVenta}</td>
            <td>${new Date(venta.fechaHora).toLocaleString('es-MX')}</td>
            <td>$${formatNumber(venta.total)}</td>
            <td><span class="status-badge ${venta.estado ? 'active' : 'inactive'}">${venta.estado ? 'Completada' : 'Cancelada'}</span></td>
        </tr>
    `).join('');
}

function formatNumber(num) {
    return num.toLocaleString('es-MX', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}