<?php

use yii\helpers\Html;
use yii\widgets\DetailView;


$this->title = $model->id;
$this->params['breadcrumbs'][] = ['label' => 'Res Users', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="res-users-view">

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
            'active',
            'login:ntext',
            'password:ntext',
            'company_id',
            'partner_id',
            'create_date',
            'signature:ntext',
            'action_id',
            'share',
            'create_uid',
            'write_uid',
            'write_date',
            'alias_id',
            'notification_type:ntext',
            'out_of_office_message:ntext',
            'odoobot_state:ntext',
            'website_id',
            'sale_team_id',
            'target_sales_won',
            'target_sales_done',
            'target_sales_invoiced',
            'karma',
            'rank_id',
            'next_rank_id',
            'livechat_username:ntext',
            'trial532',
        ],
    ]) ?>

</div>
