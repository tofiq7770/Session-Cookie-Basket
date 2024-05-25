

$(document).on("click", ".increase", function () {

    let id = parseInt($(this).attr("data-id"));

    $.ajax({
        url: `Increase?Id=${id}`,
        type: "Put",
        success: function (response) {
            $(".rounded-circle").text(response.count)
            $(".basket-total-price").text(`CART($${response.total})`);
            //$(this).prev().text(response.dbBasketCount)
            console.log(this.parentNode)
        },
    });
});

$(document).on("click", ".decrease", function () {

    let id = parseInt($(this).attr("data-id"));

    $.ajax({
        url: `Decrease?Id=${id}`,
        type: "Put",
        success: function (response) {
            $(".rounded-circle").text(response.count)
            $(".basket-total-price").text(`CART($${response.total})`);
            $(this).next().text(response.dbBasketCount)
        },
    });
})