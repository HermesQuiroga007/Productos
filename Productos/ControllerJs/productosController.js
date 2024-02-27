productosController.controller('ctrProductos', [
    '$scope',
    'productoService',
    function ($scope, productoService) {
        $scope.newProducto = {};
        $scope.productos = [];
        $scope.TipoProducto = [];

        // Cargar productos y tipo de productos al inicio
        cargarProductos();
        cargarTipoProducto();

        // Función para cargar productos
        function cargarProductos() {
        $scope.productos = productoService.GetProductos();
        $scope.TipoProducto = productoService.GetTipoProducto();
        $scope.Edit = false;
    }
]);    

//Scope lo usamos para mostrar los datos en la vista HTML y las 
//funciones de las llamadas AJAX para obtener los datos de la base de datos SQL Server 