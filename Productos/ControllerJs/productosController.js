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
            productoService.GetProductos()
                .then(function (data) {
                    $scope.productos = data;
                })
                .catch(function (error) {
                    console.error('Error al cargar productos:', error);
                });
        }

        // Función para cargar tipo de productos
        function cargarTipoProducto() {
            productoService.GetTipoProducto()
                .then(function (data) {
                    $scope.TipoProducto = data;
                })
                .catch(function (error) {
                    console.error('Error al cargar tipos de productos:', error);
                });
        }

        $scope.GuardarProducto = function () {
            productoService.InsertProducto($scope.newProducto)
                .then(function (result) {
                    if (result.Exitoso) {
                        alertify.success(result.Mensaje);
                        cargarProductos(); // Actualizar lista de productos después de la inserción
                    } else {
                        alertify.error(result.Mensaje);
                    }
                })
                .catch(function (error) {
                    console.error('Error al guardar producto:', error);
                    alertify.error('Error al guardar producto');
                });
        }

        $scope.ActualizarProducto = function (index) {
            var updateProducto = $scope.productos[index];
            productoService.ActualizarProducto(updateProducto)
                .then(function (result) {
                    if (result.Exitoso) {
                        alertify.success(result.Mensaje);
                        cargarProductos(); // Actualizar lista de productos después de la actualización
                    } else {
                        alertify.error(result.Mensaje);
                    }
                })
                .catch(function (error) {
                    console.error('Error al actualizar producto:', error);
                    alertify.error('Error al actualizar producto');
                });
        }

        $scope.EliminarProducto = function (id) {
            productoService.EliminarProducto(id)
                .then(function (result) {
                    if (result.Exitoso) {
                        alertify.success(result.Mensaje);
                        cargarProductos(); // Actualizar lista de productos después de la eliminación
                    } else {
                        alertify.error(result.Mensaje);
                    }
                })
                .catch(function (error) {
                    console.error('Error al eliminar producto:', error);
                    alertify.error('Error al eliminar producto');
                });
        }
    }
]);
