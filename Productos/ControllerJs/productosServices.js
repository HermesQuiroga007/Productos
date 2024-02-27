productosServices.factory('productoService', ['$http', function ($http) {
    return {
        GetProductos: function () {
            return $http.get("/Productos/GetProductos/")
                .then(function (response) {
                    return response.data;
                })
                .catch(function (error) {
                    console.error('Error al obtener productos:', error);
                    throw error;
                });
        },

        GetTipoProducto: function () {
            return $http.get("/Productos/GetTipoProducto/")
                .then(function (response) {
                    return response.data;
                })
                .catch(function (error) {
                    console.error('Error al obtener tipo de productos:', error);
                    throw error;
                });
        },

        InsertProducto: function (producto) {
            return $http.post("/Productos/InsertProducto/", { producto: producto })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (error) {
                    console.error('Error al insertar producto:', error);
                    throw error;
                });
        },

        ActualizarProducto: function (producto) {
            return $http.post("/Productos/ActualizarProducto/", producto)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (error) {
                    console.error('Error al actualizar producto:', error);
                    throw error;
                });
        },

        EliminarProducto: function (id) {
            return $http.post("/Productos/EliminarProducto/", { id: id })
                .then(function (response) {
                    return response.data;
                })
                .catch(function (error) {
                    console.error('Error al eliminar producto:', error);
                    throw error;
                });
        }
    };
}]);
