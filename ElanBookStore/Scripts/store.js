$(document).ready(function () {
    $('#modalSubmit').click(function () {
        if (validateAll()) {
            $('#modalForm').submit();
        } else {
            $('div.error').removeClass('hidden');
            console.log(validateAll());
            return;
        }
    });
    var checkISBN = function () {
        $('input#ISBN').blur(function () {
            var textbox = $(this);
            var contains = $('span#validation').children().length > 0;
            if (!textbox.val().trim() && $('span#spanISBN').length === 0 && !contains) {
                $('div#divISBN').append('<span class="text-danger" id="spanISBN">ISBN is required</span>');
                return false;
            } else {
                if (textbox.val().trim())
                    $('span#spanISBN').remove();
                return true;
            }
        });
    };
    var checkTitle = function () {
        $('input#Title').blur(function () {
            var textbox = $(this);

            if (!textbox.val().trim() && $('span#spanTitle').length === 0) {
                $('div#divTitle').append('<span class="text-danger" id="spanTitle">Title is required</span>');
                return false;
            } else {
                if (textbox.val().trim())
                    $('span#spanTitle').remove();
                return true;
            }
        });
    };

    var checkAuthor = function () {
        $('input#Author').blur(function () {
            var textbox = $(this);

            if (!textbox.val().trim() && $('span#spanAuthor').length === 0) {
                $('div#divAuthor').append('<span class="text-danger" id="spanAuthor">Author is required</span>');
                return false;
            } else {
                if (textbox.val().trim())
                    $('span#spanAuthor').remove();
                return true;
            }
        });
    };

    var checkGenre = function () {
        $('input#Genre').blur(function () {
            var textbox = $(this);

            if (!textbox.val().trim() && $('span#spanGenre').length === 0) {
                $('div#divGenre').append('<span class="text-danger" id="spanGenre">Genre is required</span>');
                return false;
            } else {
                if (textbox.val().trim())
                    $('span#spanGenre').remove();
                return true;
            }
        });
    };

    var validateAll = function () {
        return checkAuthor() && checkGenre() && checkISBN() && checkTitle();
    };

    checkISBN();
    checkTitle();
    checkAuthor();
    checkGenre();


    $('a.delete').click(function () {
        if (!confirm("Delete book?")) {
            return false;
        }
    });
    var showModal = function () {
        $('#theModal').modal('show');
    };

    function edit(id) {
        $.ajax({
            url: '/Books/Edit/' + id,
            success: function (data) {
                $('#wrapper').html(data);
                showModal();
            }
        });
    }


    $('#modalbtn').click(function () {
        $('#theModal').modal('show');

    });
});