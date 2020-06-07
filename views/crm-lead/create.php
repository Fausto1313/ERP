<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\ResPartner */

$this->title = 'Crear Oportunidad';
$this->params['breadcrumbs'][] = ['label' => 'CRM', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="crm-lead-create">

    <h1><?= Html::encode($this->title) ?></h1>

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>	

</div>
