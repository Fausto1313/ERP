<?php

use yii\helpers\Html;


$this->title = 'Update Sale Order Line: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Sale Order Lines', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="sale-order-line-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
