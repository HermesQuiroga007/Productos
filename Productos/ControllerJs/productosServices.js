productosServices.factory('productoService', [
    function () {
        return {
            GetProductos: function () {
                var result = null;

                $.ajax({
                    type: "GET",
                    url: "/Productos/GetProductos/",
                    contentType: "application/json;charset=utf-8",
                    data: "{}",
                    async: false,
                    dataType: "json",

                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });

                return result;
            },

            GetTipoProducto: function () {
                var result = null;

                $.ajax({
                    type: "GET",
                    url: "/Productos/GetTipoProducto/",
                    contentType: "application/json;charset=utf-8",
                    data: "{}",
                    async: false,
                    dataType: "json",

                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });

                return result;
            },

            InsertProducto: function () {
                var result = null;

                $.ajax({
                    type: "GET",
                    url: "/Productos/GetProductos/",
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify({
                        producto: producto
                    }),

                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errordata) {
                        alert(errordata.responseText);
                    }
                });

                return result;
            },
        }
    }
]);