productosController.controller('ctrProductos', [
    '$scope',
    'productoService',
    function($scope, productoService) {
        $scope.productos = productoService.GetProductos();
        $scope.TipoProducto = productoService.GetTipoProducto();
        $scope.Edit = false;
    }
]);    