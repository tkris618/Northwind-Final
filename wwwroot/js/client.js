$(function(){
    $(document).keydown(function(e) {
        // ESCAPE key pressed
        if (e.keyCode == 27) {
            $('#liveToast').toast({ autohide: false }).toast('hide');
        }
    });

    $('.code').on('click', function(e) {
        e.preventDefault();
        
        // set name
        $('#product-name').text("" + $(this).data("product"));

        // set code
        $('#code').text("" + $(this).data("code"));

        // display the toast to user
        $('#liveToast').toast({ autohide: false }).toast('show');

    });
});
