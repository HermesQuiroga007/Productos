productosController.controller('ctrProductos', [
    '$scope',
    'productoService',
    function($scope, productoService) {
        $scope.productos = productoService.GetProductos();
        $scope.TipoProducto = productoService.GetTipoProducto();
        $scope.Edit = false;
    }
]);    

//Scope lo usamos para mostrar los datos en la vista HTML y las 
//funciones de las llamadas AJAX para obtener los datos de la base de datos SQL Server 