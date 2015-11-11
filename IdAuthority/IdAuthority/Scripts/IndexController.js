app.controller("IndexController", ["$scope", "$http", function($scope, $http) {

    //$scope.itens = ["História", "Geografia", "Biologia", "Sociologia", "Filosofia", "Matemática", "Literatura", "Gramática", "Física", "Química", "Política", "Música", "Cinema"];
    $scope.itens = [
        { nome: "História", selecionado: false },
        { nome: "Geografia", selecionado: false }
        ];

    $scope.buscar = function () {
        alert($scope.itens[0].selecionado);
    };

    $scope.especialidade = [];
    $scope.palavraChave = "t";

    $scope.pessoaEncontradas = [];
    $scope.listaParaBusca = [];

    /*$scope.salvar = function() {

        $http.post("/usuario/teste", $scope.montanha)
            .success(function() {
                alert("DEU");
            })
            .error(function() {
            alert("NAO DEU");
        });
    };*/

    $scope.vincularBusca = function() {

        $scope.especialidade.forEach(function(itemLista) {

            var vinculado = {};

            vinculado.especialidade = angular.copy($scope.especialidade);
            vinculado.busca = angular.copy($scope.busca);

            $scope.listaParaBusca.push(vinculado);

        });
    }

    $scope.buscar = function () {

        $scope.vincularBusca();

        $http.get("/usuario/buscaPorEspecialidadeEPalavraChave", $scope.listaParaBusca)
            .success(function (data) {
                $scope.pessoaEncontradas = data;
                alert("DEU");
            })
            .error(function () {
                alert("NAO DEU");
            });
    };



}]);