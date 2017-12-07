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
    ajax_call();
    window.setInterval(ajax_call, interval);
}

function displayResults(data) {
    var bids = $("#bids");
    bids.empty();
    jQuery.each(data, function (i, val) {
        var buyer = val["Name"];
        var price = val["Price"];
        var timestamp = new Date(parseInt(val["Timestamp"].substr(6))).toString();
        var bidNameElement = '<h4 class="list- group - item - heading" id="bid- name">' + buyer + '</h4>';
        var bidDetailsElement = '<li class="list-group-item" id="bid-details">$' + price + ' | ' + timestamp + '</li>';

        bids.append(bidNameElement);
        bids.append(bidDetailsElement);
    })
}

function errorOnAjax()
{
    console.log("AJAX ERROR!");
}