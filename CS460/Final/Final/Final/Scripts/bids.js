function showBids(id)
{
    console.log(id);
    var source = "/Home/Bids/"+id;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        Error: errorOnAjax
    });
}

function displayResults(data)
{
    console.log("display results!")
    console.log(data);
}

function errorOnAjax()
{
    console.log("AJAX ERROR!");
}