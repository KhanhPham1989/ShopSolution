// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// <a class="btn btn-add-cart" data-id="@item.Id" href="#"> bắt sự kiên ở class btn, truyền dữ liệu vào form = data-id
// de khi bắt sự kien se lấy dc id, data-... truyền vao ki hiệu nhu the nao thi truyên vao form tuong tu

$('body').on('click', '.btn-add-cart', function (e) {
    e.preventDefault();
    const id = $(this).data('id');
    $.ajax({
        type: "POST",
        url: '/Cart/AddToCart',
        data: {
            id: id
        },
        success: function (res) {
            console.log(res)
            alert("Thanh cong add san pham")
        },
        error: function (err) {
            console.log(err);
            alert("Chua add san pham")
        }
    });
})