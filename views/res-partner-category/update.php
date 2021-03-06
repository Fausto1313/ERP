<?php

use yii\helpers\Html;


$this->title = 'Update Res Partner Category: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Res Partner Categories', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="res-partner-category-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
