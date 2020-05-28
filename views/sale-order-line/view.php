<?php

use yii\helpers\Html;
use yii\widgets\DetailView;


$this->title = $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Sale Order Lines', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="sale-order-line-view">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Update', ['update', 'id' => $model->id], ['class' => 'btn btn-primary']) ?>
        <?= Html::a('Delete', ['delete', 'id' => $model->id], [
            'class' => 'btn btn-danger',
            'data' => [
                'confirm' => 'Are you sure you want to delete this item?',
                'method' => 'post',
            ],
        ]) ?>
    </p>

    <?= DetailView::widget([
        'model' => $model,
        'attributes' => [
            'id',
            'order_id',
            'name:ntext',
            'sequence',
            'invoice_status:ntext',
            'price_unit',
            'price_subtotal',
            'price_tax',
            'price_total',
            'price_reduce',
            'price_reduce_taxinc',
            'price_reduce_taxexcl',
            'discount',
            'product_id',
            'product_uom_qty',
            'product_uom',
            'qty_delivered_method:ntext',
            'qty_delivered',
            'qty_delivered_manual',
            'qty_to_invoice',
            'qty_invoiced',
            'untaxed_amount_invoiced',
            'untaxed_amount_to_invoice',
            'salesman_id',
            'currency_id',
            'company_id',
            'order_partner_id',
            'is_expense',
            'is_downpayment',
            'state:ntext',
            'customer_lead',
            'display_type:ntext',
            'create_uid',
            'create_date',
            'write_uid',
            'write_date',
            'product_packaging',
            'route_id',
            'linked_line_id',
            'warning_stock:ntext',
            'trial555',
        ],
    ]) ?>

</div>
