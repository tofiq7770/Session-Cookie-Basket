
$(function () {

    $(document).on("click", ".show-more button", function () {

        let skip = parseInt($(".blogs-area").children().length);
        let parentElem = $(".blogs-area");
        let parentElemContent = $(".blogs-area").html();

        $.ajax({
            url: `blog/showmore?skip=${skip}`,
            type: "GET",
            success: function (response) {

                parentElemContent += response;
                $(parentElem).html(parentElemContent);
            },
        })
    })
})