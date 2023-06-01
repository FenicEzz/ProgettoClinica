let td = document.getElementsByTagName("td");
let chipNum = document.getElementById("chip").value;


let cerca = (data) => {

    let xhttp = new XMLHttpRequest();

    xhttp.onload = () => {

        let res = JSON.parse(xhttp.responseText);

        for (let x of res) {
            console.log(x.microchipNumber)
        }

        for (let x of res) {

            if (x.microchipNumber == data) {

                document.getElementsByTagName("table")[0].style.display = "table";
                td[0].innerHTML = x.id;
                td[1].innerHTML = x.registerDate;
                td[2].innerHTML = x.name;
                td[3].innerHTML = x.race;
                td[4].innerHTML = x.furColor;
                td[5].innerHTML = x.birthdate;
                td[6].innerHTML = x.hasMicrochip;
            }

            return alert("Non esiste un animale con questo numero di microchip");
        }
    }

    xhttp.open("get", "https://localhost:7124/api/recs/allpets")
    xhttp.send();
}