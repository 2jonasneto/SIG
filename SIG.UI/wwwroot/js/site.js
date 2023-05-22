showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

$("input").keyup(function () {
    if (window.location.pathname.includes('Register')) {
        return;
    }
       
    $(this).val($(this).val().toUpperCase());

})
$(document).ready(function () {
    try {

        $("input[type='text']").each(function () {
            $(this).attr("autocomplete", "off");
            if (window.location.pathname.includes('Register')) {
                return;
            }
            $(this).val($(this).val().toUpperCase());
        });
    }
    catch (e) { }
});