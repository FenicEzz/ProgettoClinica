const tbody = document.getElementById("tbody");


let cerca = (data) => {

    let xhttp = new XMLHttpRequest();
    let url = `https://localhost:7124/api/recs/petmicrochip/${data}`;


    xhttp.onload = () => {

        if (xhttp.status == 500) {

            $("#chip").css("border", "3px solid red")
            return;
        }

        $("#chip").css("border", "3px solid green")

        let obj = xhttp.responseText;

        let res = JSON.parse(obj);

        tbody.innerHTML = `<tr></tr>`;

        let value = `
            <tr>
                <td>${res.id}</td>
                <td>${res.registerDate}</td>
                <td>${res.name}</td>
                <td>${res.race}</td>
                <td>${res.furColor}</td>
                <td>${res.birthdate}</td>
                <td>${res.microchipNumber}</td>
            </tr>
        `;

        tbody.innerHTML = value;
    }

    xhttp.open("get", url)
    xhttp.send();
}