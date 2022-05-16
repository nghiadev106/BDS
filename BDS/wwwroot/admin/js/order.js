var orderController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadData();
    }

    function loadData() {
        $.ajax({
            type: "GET",
            url: '/Admin/Order/GetListItems',
            success: function (res) {
                $('.lbl_number_items_header').text(res.length);
                if (res.length === 0) {
                    $('#cart-wrapper').hide();
                    $('#emty-cart').show();
                }
                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                        var amount = item.price * item.quantity;
                    html += `<tr>
                                            <td class="text-center">
                                                  <img style="height: 123px;width: 123px;" src="`+ item.logo + `" alt="` + item.name + `" />
                                            </td>
                                            <td class="text-left">
                                                  <span>` + item.name + `</span>
                                            </td>
                                            <td class="text-center">
                                                 <span>`+ item.quantity + `</span>                                                                                                                      
                                            </td>
                                            <td class="text-right price_`+ item.id + `">` + numberWithCommas(item.price) + `</td>
                                            <td class="text-right amount_`+ item.id + `">` + numberWithCommas(amount) + `</td>
                                            <td class="text-center"><button type="button" data-id="` + item.productId + `" class="btn btn-danger deleteItem">Xóa</td>
                                        </tr>
                    `;
                    total += amount;
                });
                var footer = '  <tr><td colspan="7">Tổng tiền : ' + numberWithCommas(total)+' đ</td></tr>'
                $('.ListProduct').html(html);
                $('.ListProduct').append(footer);
            }
        });
    }

    function updateCart(id, quantity) {
        $.ajax({
            type: "POST",
            url: '/Admin/Order/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function () {
                loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    function regsiterEvents() {
        $('body').on('click', '.add-product', function (e) {
            e.preventDefault();
            var id = $("#ddlProducts option:selected").val();
            if (parseInt(id) === -1) {
                toastr.error('Bạn chưa chọn sản phẩm', 'Thất bại');
                return;
            }
            var qty_el = $("#quantity").val();  
            var quantity = parseInt(qty_el);
            if (qty_el === "")
            {
                toastr.error('Bạn chưa nhập số lượng', 'Thất bại');
                return;
            }
            if (quantity < 1) {
                toastr.error('Số lượng sản phẩm lớn hơn 0', 'Thất bại');
                return;
            }
            $.ajax({
                type: "POST",
                url: '/Admin/Order/AddToCart',
                data: {
                    id: id,
                    quantity: quantity
                },
                success: function (res) {
                    toastr.success('Thêm sản phẩm thành công', 'Thành công')
                    loadData();
                },
                error: function (err) {
                    toastr.error('Thêm sản phẩm không thành công', 'Thất bại')
                }
            });
        });

        $('body').on('click', '.deleteItem', function () {
            const id = $(this).data('id');
            updateCart(id, 0);
            loadData();
        });
    }
}

function numberWithCommas(x) {
    if (x === null || x===0) {
        return 'Liên hệ';
    }
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");   
}