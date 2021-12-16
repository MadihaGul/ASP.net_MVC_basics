function getAllPeople()
{
    $.get("/Ajax/GetPeople", null, function(data)
        {
            $("#PeopleList").html(data);
        }
    );
}

function getPeopleById() {
    var peopleId = document.getElementById('PeopleInputId').value;
    $.post("/Ajax/FindPeopleById", { PeopleId: peopleId }, function (data) {
        $("#PeopleList").html(data);

    })
}

function deleteById() {
    var peopleId = document.getElementById('PeopleInputId').value;
    $.post("/Ajax/DeletePeopleById", { PeopleId: peopleId }, null)

        .done(function () {
            document.getElementById('errorMessage').innerHTML = "Sucess! Person is deleted";
            getAllPeople();
        })
        .fail(function () {
            document.getElementById('errorMessage').innerHTML = "Error! Person could not be deleted";
        });


}