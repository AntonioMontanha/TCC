// Exemplos de chamada.

//Anexo = function (handleRevisaoPagto, handleRevisaoPagtoGuia, urlSalvar, urlExcluirAnexoNaoSalvo, urlListar, urlExcluir, urlLimparArquivos) {

//    var dropzone;

//    var mensagem = function (texto, classe) {
//        $("#msgAnexo").text(texto);
//        $("#msgAnexo").attr("class", classe);
//        $("#msgAnexo").show();
//    };

//    var bloquearDesbloquearControles = function (bloquear) {
//        $('#btnSalvarAnexo').attr('disabled', bloquear);
//        $('#btnVoltarAnexo').attr('disabled', bloquear);
//        if (dropzone != null) {
//            if (bloquear)
//                dropzone.disable();
//            else
//                dropzone.enable();
//        }
//    };

//    this.atualizarQuantidade = function (quantidade) {
//        $("#quantidadeAnexo").text(quantidade);
//    };

//    this.salvar = function () {
//        $("#msgAnexo").hide();

//        if (dropzone == null)
//            dropzone = Dropzone.forElement("#dropzoneAnexo");

//        bloquearDesbloquearControles(true);
//        $.post(urlSalvar, { handleRevisaoPagto: handleRevisaoPagto, handleRevisaoPagtoGuia: handleRevisaoPagtoGuia },
//            function (data) {
//                mensagem(data.mensagem, data.codigo == 0 ? "alert alert-success" : data.codigo == 1 ? "alert alert-warning" : "alert alert-danger");
//                listar();
//            }
//        );
//    };

//    var listar = function () {
//        if (dropzone != null)
//            dropzone.removeAllFiles();

//        $("#divListaAnexo").load(urlListar, { handleRevisaoPagto: handleRevisaoPagto, handleRevisaoPagtoGuia: handleRevisaoPagtoGuia }, function (data) {
//            bloquearDesbloquearControles(false);
//        });
//    };

//    this.remover = function (file) {
//        $.post(urlExcluirAnexoNaoSalvo, { nomeArquivo: file.name, handleRevisaoPagto: handleRevisaoPagto, handleRevisaoPagtoGuia: handleRevisaoPagtoGuia }, function (data) {
//            dropzone.removeFile(file);
//        });
//    };

//    //Remove os anexos já salvos
//    this.excluir = function (handleAnexo) {
//        if ($("#btnSalvarAnexo").is(':disabled'))
//            return;

//        if (!confirm("Deseja realmente excluir o anexo?"))
//            return;

//        bloquearDesbloquearControles(true);

//        $.post(urlExcluir, { handleAnexo: handleAnexo }, function (data) {
//            mensagem(data.mensagem, data.codigo == 0 ? "alert alert-success" : data.codigo == 1 ? "alert alert-warning" : "alert alert-danger");
//            listar();
//        });
//    };

//    var apagar = function () {
//        $.post(urlLimparArquivos, { handleRevisaoPagto: handleRevisaoPagto, handleRevisaoPagtoGuia: handleRevisaoPagtoGuia });
//    };

//    listar();
//    apagar();
//}