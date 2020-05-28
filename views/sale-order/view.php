<?php

use yii\helpers\Html;
use yii\widgets\DetailView;


$this->title = $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Sale Orders', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="sale-order-view">

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
            'campaign_id',
            'source_id',
            'medium_id',
            'message_main_attachment_id',
            'access_token:ntext',
            'name:ntext',
            'origin:ntext',
            'client_order_ref:ntext',
            'reference:ntext',
            'state:ntext',
            'date_order',
            'validity_date',
            'require_signature',
            'require_payment',
            'create_date',
            'user_id',
            'partner_id',
            'partner_invoice_id',
            'partner_shipping_id',
            'pricelist_id',
            'analytic_account_id',
            'invoice_status:ntext',
            'note:ntext',
            'amount_untaxed',
            'amount_tax',
            'amount_total',
            'currency_rate',
            'payment_term_id',
            'fiscal_position_id',
            'company_id',
            'team_id',
            'signed_by:ntext',
            'signed_on',
            'commitment_date',
            'create_uid',
            'write_uid',
            'write_date',
            'sale_order_template_id',
            'incoterm',
            'picking_policy:ntext',
            'warehouse_id',
            'procurement_group_id',
            'effective_date',
            'opportunity_id',
            'cart_recovery_email_sent:email',
            'website_id',
            'warning_stock:ntext',
            'trial539',
        ],
    ]) ?>

</div>
