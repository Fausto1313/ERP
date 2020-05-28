<?php

use yii\helpers\Html;


$this->title = 'Update Res Country State: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Res Country States', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="res-country-state-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
