<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\ResPartnerSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Clientes';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-partner-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Cliente', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'id',
            'name:ntext',
            'company_id',            
            'email',
            'create_date',
            //'date',
            //'title',
            //'parent_id',
            //'ref:ntext',
            //'lang:ntext',
            //'tz:ntext',
            //'user_id',
            //'vat:ntext',
            //'website:ntext',
            //'comment:ntext',
            //'credit_limit',
            //'active',
            //'employee',
            //'function:ntext',
            //'type:ntext',
            //'street:ntext',
            //'street2:ntext',
            //'zip:ntext',
            //'city:ntext',
            //'state_id',
            //'country_id',
            //'partner_latitude',
            //'partner_longitude',
            //'email:ntext',
            //'phone:ntext',
            //'mobile:ntext',
            //'is_company',
            //'industry_id',
            //'color',
            //'partner_share',
            //'commercial_partner_id',
            //'commercial_company_name:ntext',
            //'company_name:ntext',
            //'create_uid',
            //'write_uid',
            //'write_date',
            //'message_main_attachment_id',
            //'email_normalized:ntext',
            //'message_bounce',
            //'signup_token:ntext',
            //'signup_type:ntext',
            //'signup_expiration',
            //'partner_gid',
            //'additional_info:ntext',
            //'phone_sanitized:ntext',
            //'website_id',
            //'is_published',
            //'calendar_last_notif_ack',
            //'team_id',
            //'picking_warn:ntext',
            //'picking_warn_msg:ntext',
            //'debit_limit',
            //'last_time_entries_checked',
            //'invoice_warn:ntext',
            //'invoice_warn_msg:ntext',
            //'supplier_rank',
            //'customer_rank',
            //'sale_warn:ntext',
            //'sale_warn_msg:ntext',
            //'purchase_warn:ntext',
            //'purchase_warn_msg:ntext',
            //'website_meta_title:ntext',
            //'website_meta_description:ntext',
            //'website_meta_keywords:ntext',
            //'website_meta_og_img:ntext',
            //'website_description:ntext',
            //'website_short_description:ntext',
            //'customer',
            //'trial496',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
