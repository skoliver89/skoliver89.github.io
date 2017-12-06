function showBids(id)
{
    var ajax_call = function () {
        console.log(id);
        source = "/Home/Bids/" + id;
        $.ajax({
            type: "GET",
            dataType: "json",
            url: source,
            success: displayResults,
            Error: errorOnAjax
        });
    }
    var seconds = 5;
    var interval = 1000 * seconds;

    window.setInterval(ajax_call, interval);
}

function displayResults(data)
{
    console.log(data);
}

function errorOnAjax()
{
    console.log("AJAX ERROR!");
}