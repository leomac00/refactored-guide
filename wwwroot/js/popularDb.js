const popularDb = () => {
  console.log("Populando banco de dados...");
  let endereco = "https://localhost:5001/Admin/PopularDb";
  const dados = {
    dados: "dummyData",
  };
  const dadosJSON = JSON.stringify(dados);
  $.ajax({
    type: "POST",
    url: endereco,
    dataType: "json",
    contentType: "application/json",
    data: dadosJSON,
    success: function (data) {
      alert(`Tabelas populadas [${data.qtd} / 6]: \n` + data.msg);
      console.log("Feito!");
    },
    error: function (xhr, ajaxOptions, thrownError) {
      alert("Banco de dados não populado");
      console.log(xhr.status);
      console.log(thrownError);
    },
  });
};
