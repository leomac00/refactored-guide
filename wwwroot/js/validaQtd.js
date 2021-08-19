$(document).ready(function () {
  let QtdRecebida = $("#QtdRecebida").val();
  let QtdRestante = $("#QtdRestante").val();

  if (QtdRecebida > QtdRestante) {
    $("form").submit(function (e) {
      e.preventDefault();
      alert("Quantidade recebida não pode ser maior que a restante!");
    });
  } else {
    $("form").submit(function (e) {
      //Init
      e.preventDefault();
      const endereco = "https://localhost:5000/LotesVacinas/Editar";
      //Pega dados do formulario
      let VacinaId = $("#VacinaId").val();
      let Lote = $("#Lote").val();
      let QtdRecebida = $("#QtdRecebida").val();
      let QtdRestante = $("#QtdRestante").val();
      let DataRecebimento = $("#DataRecebimento").val();
      let DataValidade = $("#DataValidade").val();
      //Transformação para JSON
      let dados = {
        VacinaId: VacinaId,
        Lote: Lote,
        QtdRecebida: QtdRecebida,
        QtdRestante: QtdRestante,
        DataRecebimento: DataRecebimento,
        DataValidade: DataValidade,
      };
      dados = JSON.stringify(dados);
      console.log(dados);
      //Envia para o controller
      $.ajax({
        type: "POST",
        url: endereco,
        dataType: "json",
        contentType: "application/json",
        data: dados,
        success: function (data) {
          console.log("Dados enviados com sucesso");
          console.log(data);
        },
      });
    });
  }
});
