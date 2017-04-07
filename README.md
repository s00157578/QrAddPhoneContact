(function () {
    "use strict";

    angular
        .module("OrderManagement")
        .controller("OrderCtrl",
            ["OrderResource",
                OrderCtrl]);

    function OrderCtrl(OrderResource) {
        /* jshint validthis:true */
        var vm = this;
        vm.Lines = [];
        OrderResource.orders.query(function (data) {
            vm.orders = data;
        });
        vm.getOrderWithProducts = function (orderId) {
            OrderResource.ordersWithProducts.query({ id: orderId },
            function (data) {
                vm.productOrderLines = data;
            });
        };

        vm.showOrderLines = function (orderId) {
            vm.Lines = [];
            angular.forEach(vm.orders,
                function (ord) {
                    if (ord.orderId == orderId) {
                        angular.forEach(ord.orderLines,
                            function (line) {
                                vm.Lines.push(line);
                            });
                        console.debug(vm.Lines);
                    }
                }
        );
        };
        $scope.editOrder= function (order) {
            debugger;
            var getData = OrderResource.getEmployee(employee.Id);
            getData.then(function (emp) {
                $scope.employee = emp.data;
                $scope.employeeId = employee.Id;
                $scope.employeeName = employee.name;
                $scope.employeeEmail = employee.email;
                $scope.employeeAge = employee.Age;
                $scope.Action = "Update";
                $scope.divEmployee = true;
            },
            function () {
                alert('Error in getting records');
            });
        }
    }
})();
    
