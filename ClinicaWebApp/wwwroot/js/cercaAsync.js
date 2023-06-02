let td = document.getElementsByTagName("td");
let chipNum = document.getElementById("chip").value;


let cerca = (data) => {

    let xhttp = new XMLHttpRequest();

    xhttp.onload = () => {

        let res = JSON.parse(xhttp.responseText);

        for (x of res) {

            if (x.microchipNumber == data) {

                $("#chip").css("border", "3px solid green")
                td[0].innerHTML = x.id;
                td[1].innerHTML = x.registerDate;
                td[2].innerHTML = x.name;
                td[3].innerHTML = x.race;
                td[4].innerHTML = x.furColor;
                td[5].innerHTML = x.birthdate;
                td[6].innerHTML = x.microchipNumber;
            }
            else {
                $("#chip").css("border", "3px solid red")
            }
        }
    }


    xhttp.open("get", "https://localhost:7124/api/recs/allpets")
    xhttp.send();

}
