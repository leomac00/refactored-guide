const consultaCep = async () => {
  const cep = $("#cep").val().replace(/\D/g, "");
  const url = "https://viacep.com.br/ws/" + cep + "/json/";

  //Limpa campos
  $("#Logradouro").val("");
  $("#Complemento").val("");
  $("#Cidade").val("");
  $("#Estado").val("");

  if (cep.length != 8) {
    alert("Cep deve ter 8 caracteres numéricos");
  } else {
    const dados = await $.getJSON(url);
    if (dados.erro) {
      alert("Cep não encontrado");
    } else {
      //insere dados nos campos
      $("#Logradouro").val(dados.logradouro);
      $("#Complemento").val(dados.complemento);
      $("#Cidade").val(dados.localidade);
      $("#Estado").val(dados.uf);
    }
  }
};
