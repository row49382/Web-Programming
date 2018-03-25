var url = "http://localhost:59067/api/Pokemon";
var hackedUrl = "http://localhost:59067/api/HackedPokemon"

function runPost()
{
    clearDivs();
    clearList();
    hideList();
    $.ajax(url,
        {
            method: "POST",
            contentType: "application/json",
            success: getResult,
            error: getError,
            data: JSON.stringify(
            {
                    Name: document.getElementById("pokemon").value,
                    Id: document.getElementById("entryNumber").value,
                    Level: document.getElementById("levelNumber").value,
                    MoveOne: document.getElementById("moveOne").value,
                    MoveTwo: document.getElementById("moveTwo").value,
                    MoveThree: document.getElementById("moveThree").value,
                    MoveFour: document.getElementById("moveFour").value
            })
        });
}

function runGet()
{
    clearDivs();
    
    $.ajax(url,
        {
            method: "GET",
            contentType: "application/json",
            success: populateList,
            error: getError
        });
}

function runDelete()
{
    var position = checkedRB();
    debugger;
    if (position !== 0) {

        $.ajax(url + "/" + position,
            {
                method: "POST",
                contentType: "application/json",
                success: populateList,
                error: getError
            });
    }
    else
    {
        getError("Choose a Pokemon before clicking delete");
    }
}

function runHackedPost()
{
        clearDivs();
        clearList();
        hideList();

        $.ajax(hackedUrl,
            {
                method: "POST",
                contentType: "application/json",
                success: getResult,
                error: getError,
                headers:
                {
                    "authorization": "Bearer: " + localStorage.getItem("MissingNo")
                },
                data: JSON.stringify(
                    {
                        Name: document.getElementById("pokemon").value,
                        Id: document.getElementById("entryNumber").value,
                        Level: document.getElementById("levelNumber").value,
                        MoveOne: document.getElementById("moveOne").value,
                        MoveTwo: document.getElementById("moveTwo").value,
                        MoveThree: document.getElementById("moveThree").value,
                        MoveFour: document.getElementById("moveFour").value
                    })
            });

}

function changeVisibility()
{
    if (checkedRB() !== 0)
    {
        document.getElementById("delete").disabled = false;
    }
}

function getResult(data)
{
    if (data.length > 500)
    {
        runAuthorizedResult(data);
    }
    else
    {
        document.getElementById("result").innerHTML = JSON.stringify(data);
    }
}

function runAuthorizedResult(data)
{
    localStorage.setItem("MissingNo", data);
    document.getElementById("hidden").disabled = false;
}

function getError(data)
{
    document.getElementById("error").innerHTML = JSON.stringify(data);
}

function populateList(data)
{
    clearList();
    showList();
    if (document.getElementById("hidden").disabled === false)
    {

    }
    for (var i = 0; i < data.length; i++)
    {
        document.getElementById("pos" + (i + 1)).innerText = JSON.stringify(data[i]);  
    }
}

function clearList()
{
    for (var i = 0; i < 6; i++)
    {
        document.getElementById("pos" + (i + 1)).innerText = "";
    }
}

function clearDivs()
{
    document.getElementById("result").innerHTML = "";
    document.getElementById("error").innerHTML = "";
}

function hideList()
{
    for (var i = 0; i < 6; i++)
    {
        document.getElementById("pos" + (i + 1)).style.visibility = "hidden";
    }
}

function showList()
{
    for (var i = 0; i < 6; i++)
    {
        document.getElementById("pos" + (i + 1)).style.visibility = "visible";
    }
}

function checkedRB()
{
    var radios = document.getElementsByTagName('input');
    var value = 0;
    for (var i = 0; i < radios.length; i++) {
        if (radios[i].type === 'radio')
        {
            value++;
            if (radios[i].checked) {
                return value;
            }
        }
    }
    return 0;
}