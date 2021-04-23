

class Cliente {

    Nome;
    CPF;
    DataNascimento;
    RendaFamiliar;

    constructor(nome, cPF, dataNascimento, rendaFamilia) {

        this.Nome = nome;
        this.CPF = cPF;
        this.DataNascimento = dataNascimento;
        this.RendaFamiliar = rendaFamilia;
    }
}

function PostForm() {

    let data = Form();

    let dataJson = JSON.stringify(data)

    console.log(dataJson);

    //$.post("https://localhost:44342/api/Cliente", dataJson)
    //  .fail(m => console.log(m));

    
     $.ajax({
        type: "POST",
        url: "https://localhost:44342/api/Cliente",
        data: dataJson,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: (s) => console.log(s),
        error: function (response) {
            console.log(response);
        }
              
    });
    

}

function Form() {

    let cliente = new Cliente();

    cliente.Nome = document.getElementById("FormName").value;

    cliente.CPF = document.getElementById("FormCPF").value;

    cliente.DataNascimento = document.getElementById("FormDateBorn").value;

    cliente.RendaFamiliar = document.getElementById("FormRenda").value;

    return cliente;
}

document.getElementById("btnPost").addEventListener("click", function (event) {
    event.preventDefault();
    PostForm();
})