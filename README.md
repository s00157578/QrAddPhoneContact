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
   =================================================
   <!DOCTYPE html>
<html>
<head>
    <title></title>
	<meta charset="utf-8" />
</head>
<body>
    <div class="panel panel-primary"
         ng-controller="OrderCtrl as vm">
        <div class="panel-heading"
             style="font-size:large">
            Orders List
        </div>

        <div class="panel-body">
            <table class="table">
                <thead class="table-info">
                    <tr>
                        <td>Order Id</td>
                        <td>Customer Name</td>
                        <td>Order Date</td>
                        <td>Entered By</td>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="order in vm.orders">
                        <td>{{order.orderId}}</td>
                        <td>{{order.customers.name}}</td>
                        <td>{{order.orderDate |date}}</td>
                        <td>{{order.enteredBy}}</td>
                        <td>
                            <button ng-click="vm.getOrderWithProducts(order.orderId)">
                                Show Order Lines
                            </button>
                            <span ng-click="editOrder(order)" class="btnAdd">Edit</span>
                            <span ng-click="deleteOrder(order)" class="btnRed">Delete</span>
                        <
                        </td>
                    </tr>
                </tbody>
            </table>
            <table>
                <thead class="table-info">
                    <tr>
                        <td>OrderLine Id</td>
                        <td>Product Id </td>
                        <td>Description</td>
                        <td>Quantity</td>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="line in vm.productOrderLines">
                        <td>{{line.orderLineId}}</td>
                        <td>{{line.productId}}</td>
                        <td>{{line.products.decription}}</td>
                        <td>{{line.quantity}}</td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>
</body>
</html>

