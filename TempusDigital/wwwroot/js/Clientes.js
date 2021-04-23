function GetClientes(nome) {

    if (nome != undefined) 
        nome = "?nome=" + nome;
    else
        nome = ""

    $.get("https://localhost:44342/api/Cliente/Brief" + nome)
        .done(function (data) {

            MakeList(data);

        });
}

function TestClientColor(rendaFamiliar) {

    if (rendaFamiliar <= 980) 
        return "red"
    
    else if (rendaFamiliar <= 2500) 
        return "yellow"
    
    else
        return "green"

}

function MakeList(data) {

    let section = document.getElementById("Lista")

    section.innerHTML = "";

    let ul = document.createElement("ul")
    ul.classList.add("list-group", "list-group-flush")

    data.forEach(function(value) {
        let li = document.createElement("li")
        li.classList.add("list-group-item")

        let small = document.createElement("small")
        small.innerHTML = "R$ " + value.rendaFamiliar
        small.classList.add("money-badge", TestClientColor(value.rendaFamiliar))

        li.innerHTML = value.nome + " ";
        li.appendChild(small);

        ul.appendChild(li);

    })

    section.appendChild(ul);
}

function SearchEventlistening() {

    let searchform = document.getElementById("search-by-name");

    searchform.addEventListener("input", function (e) {

        setTimeout(function () { GetClientes(e.target.value); }, 0500)
        
    })

}

GetClientes()
SearchEventlistening()
