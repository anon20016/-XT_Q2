document.getElementById("count").addEventListener('click', 
function(e) {
    var str = document.getElementById("text").value;
    var answer;
    while (true) {
        var regx1 = str.match(/^(([\+|-]?(([1-9][0-9]*)|([0-9]))\.[0-9]{1,})|([\+|\-]?(([1-9][0-9]*)|([0-9]))))/);
        var number1 = +regx1[0];
        str = str.replace(number1, '').trim();
        var sign = str[0];
        if (sign === "=") {
            break;
        }
        str = str.substring(1);
        var regx2 = str.match(/^(([\+|-]?(([1-9][0-9]*)|([0-9]))\.[0-9]{1,})|([\+|\-]?(([1-9][0-9]*)|([0-9]))))/);
        var number2 = +regx2[0];
        if (sign === "+") {
            answer = number1 + number2;
        }
        else if (sign === "*") {
            answer = number1 * number2;
        }
        else if (sign === "-") {
            answer = number1 - number2;
        }
        else if (sign === "/") {
            answer = number1 / number2;
        }
        str = str.replace(number2, answer).trim();
    }
    
    document.getElementById("result").value = answer.toFixed(2);
});
