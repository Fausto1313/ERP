<?php

use yii\helpers\Html;


$this->title = 'Update Utm Campaign: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'Utm Campaigns', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="utm-campaign-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
