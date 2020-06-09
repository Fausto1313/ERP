<?php

use yii\helpers\Html;


$this->title = 'Update Compañia: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Compañia', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="res-company-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
