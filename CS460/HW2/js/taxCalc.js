console.log("Loaded the page!");

function clicked () {
    console.log("clicked the button!!!");
    //get the values from the html/bootstrap form
    //make sure to make the string of a number in value a number type.
    //note: the bootstrap bit in the form forces the value to be a number.
    var value = Number(document.getElementById("value").value);
    var state = document.getElementById("state").value;
    //double-check that the value is positive
    if (value > 0) {
        console.log("value = $" + value);
        console.log("state = " + state);
        var tax = "$" + calcTax(value, state);
        console.log("taxAmount = " + tax);
        
        //add the output to the html page
        $("#amount").text(tax);
        $("#flag").css("display", "block");
        $("#amntLabel").css("display", "block");
        $("#amount").css("display", "block");
        
    }
    else {
        console.log("Home value not valid (0-inf)!");
        alert("Home value not valid (0-inf)!"); //alert the user of their error
    }
}

function calcTax(value, state){
    var tax = value * readState(state);
    return tax;
}

function readState(state){
    var rate = 0;
    switch(state) { //get rate by state (only 3 for PoC so switch-case works)
        case "CA":
            rate = 0.74;
            $("#flag").attr("src", "assets/CAflag.png");
            break;
        case "OR":
            rate = 0.87;
            $("#flag").attr("src", "assets/ORflag.png");
            break;            
        case "WA":
            $("#flag").attr("src", "assets/WAflag.png");
            rate = 0.92;
    }
    rate /= 100; //convert the percentage into a usable number.
    return rate;
}