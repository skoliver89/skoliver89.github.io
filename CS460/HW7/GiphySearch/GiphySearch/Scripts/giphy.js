var page = 1;

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

$("#search").click(newSearch); //when the search button is click run a new search
$("#next").click(nextPage); //page the results up
$("#prev").click(prevPage); //page the results down

function newSearch() {
    page = 1;
    search();
}

function nextPage() {
    page += 1;
    search();
}

function prevPage() {
    page -= 1;
    search();
}
function search() {
    var q = $("#query").val();
    var rating = $("#rating").val();
    var lang = $("#lang").val();
    var source = "gif/searcher/" + page + "?q=" + q + "&rating=" + rating + "&lang=" + lang;
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        error: errorOnAjax 
    });
}


function displayResults(data) {
    $("#results").css("display", "grid");
    //console.log(data);
    console.log(data.pagination.total_count);
    //console.log(data.pagination.count);
    //console.log(data.pagination.offset);
    //console.log((data.pagination.count + data.pagination.offset));
    //console.log(data.data[0].images.fixed_width.url);
    var animate = $("input[name=animated]:checked").val();
    console.log("Animate? " + animate);
    if (data.pagination.total_count > 0)
    {
        for (i = 0; i < 9; i++) {
            var id = "#gif-" + (i + 1);
            if (data.data[i]) {
                if (animate == "yes") {
                    $(id).attr('src', data.data[i].images.fixed_width.url);
                }
                else if (animate == "no") {
                    $(id).attr('src', data.data[i].images.fixed_width_still.url);
                }
            }
        }
    }
    else {
        for (i = 0; i < 9; i++) {
            var id = "#gif-" + (i + 1);
            $(id).attr('src', "https://media2.giphy.com/media/YyKPbc5OOTSQE/200w.gif");
        }
    }
    //console.log("page: " + page);
    if (page == 1) {
        //console.log("PAGE 1 - Disable Previous button!");
        $('#prev').prop('disabled', true);
    }
    else {
        //console.log("PAGE > 1 - Enable Previous button!");
        $('#prev').prop('disabled', false);
    }
    
    // if (data.pagination.count + data.pagination.offset) == data.pagination.total_count
    // we are on the last page
    // (data.pagination.count + data.pagination.offset) will never be > data.pagination.total_count
    if ((data.pagination.count + data.pagination.offset) == data.pagination.total_count) {
        //console.log("Last Page - Disable next button!");
        $('#next').prop('disabled', true);
    }
    else {
        //console.log("Not Last Page - Enable next button!");
        $('#next').prop('disabled', false);
    }
}

function errorOnAjax() {
    console.log("error");
}

