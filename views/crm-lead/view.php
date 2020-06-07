<?php

use yii\helpers\Html;
use yii\widgets\DetailView;

/* @var $this yii\web\View */
/* @var $model app\models\ResPartner */

$this->title = $model->name;
$this->params['breadcrumbs'][] = ['label' => 'CRM', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="crm-lead-view">

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
            //'email_cc',
            //'message_main_attachment_id' ,
            //'message_bounce',
            'email_normalized',
            //'campaign_id',
            //'source_id',
            //'medium_id',
            'name'  ,
            'partner_id',
            //'active' ,
            //'date_action_last',
            //'email_from',
            //'website',
            //'team_id',
            'description',
            //'contact_name',
            //'partner_name',
            'type',
            'priority',
            //'date_closed',
            //'stage_id',
            'user_id' ,
            //'referred',
            'date_open' ,
            //'day_open' ,
            //'day_close' ,
            //'date_last_stage_update',
            //'date_conversion' ,
            'probability',
            //'automated_probability',
            //'phone_state' ,
            //'email_state',
            'planned_revenue',
            //'expected_revenue',
            //'date_deadline',
            //'color',
            'street',
            //'street2',
            'zip',
            'city',
           // 'state_id',
            'country_id',
            //'lang_id' ,
            'phone' ,
            'mobile' ,
            'function',
            //'title' ,
            'company_id',
            //'lost_reason' ,
            //'create_uid' ,
            //'create_date',
            //'write_uid' ,
            //'write_date',
            //'trial242' ,
        ],
    ]) ?>

</div>
