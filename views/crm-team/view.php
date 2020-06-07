<?php

use yii\helpers\Html;
use yii\widgets\DetailView;


$this->title = $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Equipos de Ventas', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
\yii\web\YiiAsset::register($this);
?>
<div class="crm-team-view">

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
            //'message_main_attachment_id',
            'name',
           // 'sequence',
            //'active',
            'company_id',
            //'user_id',
            //'color',
            'create_uid',
            'create_date',
            //'write_uid',
            //'write_date',
            //'use_leads',
           // 'use_opportunities',
            'alias_id',
            //'use_quotations',
            //'invoiced_target',
            //'trial304',
        ],
    ]) ?>

</div>
