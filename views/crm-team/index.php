<?php

use yii\helpers\Html;
use yii\grid\GridView;


$this->title = 'Equipos de Ventas';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="crm-team-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name',
            //'active',
            'company_id',
            'create_date',
            //'access_token:ntext',
            //'name:ntext',
            //'origin:ntext',
            //'client_order_ref:ntext',
            //'reference:ntext',
            //'state:ntext',
            //'date_order',
            //'validity_date',
            //'require_signature',
            //'require_payment',
            //'create_date',
            //'user_id',
            //'partner_id',
            //'partner_invoice_id',
            //'partner_shipping_id',
            //'pricelist_id',
            //'analytic_account_id',
            //'invoice_status:ntext',
            //'note:ntext',
            //'amount_untaxed',
            //'amount_tax',
            //'amount_total',
            //'currency_rate',
            //'payment_term_id',
            //'fiscal_position_id',
            //'company_id',
            //'team_id',
            //'signed_by:ntext',
            //'signed_on',
            //'commitment_date',
            //'create_uid',
            //'write_uid',
            //'write_date',
            //'sale_order_template_id',
            //'incoterm',
            //'picking_policy:ntext',
            //'warehouse_id',
            //'procurement_group_id',
            //'effective_date',
            //'opportunity_id',
            //'cart_recovery_email_sent:email',
            //'website_id',
            //'warning_stock:ntext',
            //'trial539',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
