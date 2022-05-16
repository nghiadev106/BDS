$(document).ready(function () {
    loadData();
    registerEvents();
});

function registerEvents() {
    $('body').on('click', '.btn-plus', function (e) {
        e.preventDefault();
        const id = $(this).data('id');
        const quantity = parseInt($('#txt_quantity_' + id).val()) + 1;
        updateCart(id, quantity);
    });

    $('body').off('click').on('click', '#removeItem', function (e) {
        e.preventDefault();
        const id = $(this).data('id');
        updateCart(id, 0);
        location.reload();
    });
}

function updateCart(id, quantity) {
    $.ajax({
        type: "POST",
        url: '/Cart/UpdateCart',
        data: {
            id: id,
            quantity: quantity
        },
        success: function (res) {
            $('#lbl_number_items_header').text(res.length);
        },
        error: function (err) {
            console.log(err);
        }
    });
}


function loadData() {

    $.ajax({
        type: "GET",
        url: '/Cart/GetListItems',
        success: function (res) {
            if (res.length === 0) {
                $('#cart-wrapper').hide();
                $('#emty-cart').show();
            }
            var html = '';
            var total = 0;

            $.each(res, function (i, item) {
                var amount = item.price * item.quantity;
                html += `<div class="cart_detail">

                    <a id="removeItem" data-id="`+ item.productId + `" class="remove" href=""></a>
                    <div class="cart_ig">
                        <img  alt="`+ item.name + `" title="` + item.name + `" src="` + item.logo + `" style="border-width:0px;">
                    </div>
                    <div class="cart_in">
                        <h3>
                            <a title="Hạnh phúc bất tận 2" href="/san-pham/`+ item.Url + `/` + item.productId + `">` + item.name + `</a>
                            <span>
                                <strong>
                                    Mã SP:
                                </strong>`+ item.productId + `
                            </span>
                        </h3>
                        <div class="pri">
                            <span>
                                Đơn giá:
                            </span>
                            `+ item.price + ` đ
                        </div>
                        <div class="qly">
                            <span>
                                Số lượng:
                            </span>
                            <select id="quantity" data-id="`+ item.productId + `"  onchange="getval(this);">
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                                <option value="7">7</option>
                                <option value="8">8</option>
                                <option value="9">9</option>
                                <option value="10">10</option>
                            </select>
                        </div>
                    </div></div>
                    `;
                total += amount;
            });
            $('.ListCart').html(html);
            $('.lbl_number_of_items').text(res.length);
            $('.lbl_total').text(total);
            $('.lbl_number_items_header').text(res.length);
        }
    });
}
function getval(sel) {
    const id = $("#quantity").data('id');
    const quantity = sel.value;
    updateCart(id, quantity);
    //location.reload();
}