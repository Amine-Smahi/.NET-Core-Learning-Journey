

$(function () {
    
    $("#msgs li").each(function () {
        var classe = $(this).data("classe");
        var text = $(this).text().trim();

        showStackTopCenter(classe, text);
    });
});

function showStackTopCenter(type, text_) {

    if (typeof window.stackTopCenter === 'undefined') {
        window.stackTopCenter = {
            'dir1': 'down',
            'firstpos1': 50
        };
    }
    var opts = {
        type: type,
        text: text_,
        stack: window.stackTopCenter,
        closer: true,
        history: false,
        styling: "bootstrap3",
        icons: 'bootstrap3'
    };

    PNotify.alert(opts);
}