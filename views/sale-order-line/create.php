<?php

use yii\helpers\Html;


$this->title = 'Create Sale Order Line';
$this->params['breadcrumbs'][] = ['label' => 'Sale Order Lines', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="sale-order-line-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
