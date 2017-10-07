console.log("Loaded the page!");
$("button").click(function(){
    clicked();
});
function clicked () {
    console.log("clicked the button!!!");
    //get the values from the html/bootstrap form
    //make sure to make the string of a number in value a number type.
    //note: the bootstrap bit in the form forces the value to be a number.
    var value = Number(document.getElementById("value").value).toFixed(2);
    var state = document.getElementById("state").value;
    //double-check that the value is positive
    if (value > 0) {
        console.log("value = $" + value);
        console.log("state = " + state);
        var rate = Number(readState(state));
        var tax = Number(calcTax(value, rate)).toFixed(2);
        console.log("rate = " + (rate * 100) + "%");
        console.log("taxAmount = " + tax);
        
        //add the output to the html page
        displayInfo(value, rate, tax);  
    }
    else {
        console.log("Home value not valid (0-inf)!");
        alert("Home value not valid (0-inf)!"); //alert the user of their error
    }
}
function calcTax(value, rate){
    var tax = value * rate;
    return tax;
}
function readState(state){
    var rate = 0.00;
    switch(state) { //get rate by state (only 3 for PoC so switch-case works)
        case "CA":
            rate = 0.74;
            $("#flag").attr("src", "assets/CAflag.png"); //change flag
            break;
        case "OR":
            rate = 0.87;
            $("#flag").attr("src", "assets/ORflag.png"); //change flag
            break;            
        case "WA":
            $("#flag").attr("src", "assets/WAflag.png"); //change flag
            rate = 0.92;
    }
    rate /= 100; //convert the percentage into a usable number.
    return rate;
}
function displayInfo(value, rate, tax){ 
    $("#flag").css("display", "block");
    var item = document.getElementById("data");
    item.innerHTML = '<dl id="dList"></dl>';
    item = document.getElementById("dList");
    item.innerHTML =  "<dt>Home Value($):</dt>";
    item.innerHTML += "<dd>"+value+"</dd>";
    item.innerHTML += "<dt>Tax Rate(%):</dt>";
    item.innerHTML += "<dd>"+(rate*100)+"</dd>";
    item.innerHTML += "<dt>Tax Amount($):</dt>";
    item.innerHTML += "<dd>"+tax+"</dd>";
}