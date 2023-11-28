$(function () {
    $(document).keydown(function(e) {
        // ESCAPE key pressed
        if (e.keyCode == 27) {
            $('#home_toast').toast({ autohide: false }).toast('hide');
        }
    });

    $('.code').on('click', function(e) {
        e.preventDefault();
        
        // set name
        $('#home_toast_header').text("" + $(this).data("product"));

        // set code
        $('#home_toast_body').text("" + $(this).data("code"));

        // display the toast to user
        $('#home_toast').toast({ autohide: false }).toast('show');

    });
});
