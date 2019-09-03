$(document).ready(function () {
    $("#1").click(function () {
        $(".left>li").css({
            opacity: "0"
        });
        $(".right>li").css({
            opacity: "1",
            position: "static",
            background: "#ffffff"
        });
    });

    $("#4").click(function () {
        $(".left>li").css({
            opacity: "1",
            position: "static",
            background: "#ffffff"
        });
        $(".right>li").css({
            opacity: "0"
        });
    });

    $(".left>li#opt1").click(function () {
        $(this).addClass("activeLeft").removeClass("activeRight").css({
            background: "#A3C8F5"
        });
        $(".right>li#opt1").addClass("activeLeft").removeClass("activeRight");
    });
    
    $(".left>li#opt2").click(function () {
        $(this).addClass("activeLeft").removeClass("activeRight").css({
            background: "#A3C8F5"
        });
        $(".right>li#opt2").addClass("activeLeft");
    });
    
    $(".left>li#opt3").click(function () {
        $(this).addClass("activeLeft").removeClass("activeRight").css({
            background: "#A3C8F5"
        });
        $(".right>li#opt3").addClass("activeLeft");
    });
    
    $(".left>li#opt4").click(function () {
        $(this).addClass("activeLeft").removeClass("activeRight").css({
            background: "#A3C8F5"
        });
        $(".right>li#opt4").addClass("activeLeft");
    });
    
    $(".left>li#opt5").click(function () {
        $(this).addClass("activeLeft").removeClass("activeRight").css({
            background: "#A3C8F5"
        });
        $(".right>li#opt5").addClass("activeLeft");
    });

    $("#2").click(function () {
        $(".left>li.activeLeft").css({
            position: "absolute",
            bottom: "100px",
            opacity: "0"
        });
        $(".right>li.activeLeft").css({
            position: "static",
            opacity: "1",
            background: "#ffffff"
        });
    });

    $(".right>li#opt1").click(function () {
        $(this).addClass("activeRight").removeClass("activeLeft").css({
            background: "#A3C8F5"
        });
        $(".left>li#opt1").addClass("activeRight").removeClass("activeLeft");
    });

    $(".right>li#opt2").click(function () {
        $(this).addClass("activeRight").removeClass("activeLeft").css({
            background: "#A3C8F5"
        });
        $(".left>li#opt2").addClass("activeRight").removeClass("activeLeft");
    });

    $(".right>li#opt3").click(function () {
        $(this).addClass("activeRight").removeClass("activeLeft").css({
            background: "#A3C8F5"
        });
        $(".left>li#opt3").addClass("activeRight").removeClass("activeLeft");
    });

    $(".right>li#opt4").click(function () {
        $(this).addClass("activeRight").removeClass("activeLeft").css({
            background: "#A3C8F5"
        });
        $(".left>li#opt4").addClass("activeRight").removeClass("activeLeft");
    });

    $(".right>li#opt5").click(function () {
        $(this).addClass("activeRight").removeClass("activeLeft").css({
            background: "#A3C8F5"
        });
        $(".left>li#opt5").addClass("activeRight").removeClass("activeLeft");
    });


    $("#3").click(function () {
        $(".right>li.activeRight").css({
            position: "absolute",
            bottom: "100px",
            opacity: "0"
        });
        $(".left>li.activeRight").css({
            position: "static",
            opacity: "1",
            background: "#ffffff"
        });
    });
});
