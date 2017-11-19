//a key is pressed in the #query text-field
$("#query").keypress(function (event) {
    //if the key is enter (13)
    if (event.keyCode == 13) {
        //run the search function
        search();
        //prevent generating a querystring
        event.preventDefault(); 
    }
});

$("#search").click(search); //when the search button is click run the search function

function search() {
    var q = $("#query").val();
    var source = "gif/searcher?q=" + q
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        error: errorOnAjax 
    });
}


function displayResults(data) {
    //console.log(data);
    $("#results").css("display", "grid");

    //console.log(data);
    //console.log(data.data[0].images.fixed_width.url);
    for (i = 0; i < 9; i++)
    {
        var id = "#gif-" + (i + 1);
        $(id).attr('src', data.data[i].images.fixed_width.url);
    }
}

function errorOnAjax() {
    console.log("error");
}