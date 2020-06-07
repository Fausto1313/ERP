<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\ResPartner */

$this->title = 'Update Oportunidad: ' . $model->name;
$this->params['breadcrumbs'][] = ['label' => 'CRM', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->name, 'url' => ['view', 'id' => $model->id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="crm-lead-update">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
