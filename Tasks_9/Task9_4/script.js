$(document).ready(function () {
    $('.menu a').each(function () {
        var location = window.location.href;
        var link = this.href;
        if (location == link) {
            $(this).addClass('active');
        }
    });

    $('#close').click(   function exit() {
    window.open('page4.html', '_self');
        var exit = confirm("Close page?");
        if (exit) {
             window.close();
        }
    });
    
    $('#12').click( function exit() {
       window.open('page4.html', '_self');

    });
});
